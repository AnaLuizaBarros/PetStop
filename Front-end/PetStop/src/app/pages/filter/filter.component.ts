import { PorteService } from './../../service/porte.service';
import { AdotanteService } from './../../service/adotante.service';
import { DoadorService } from './../../service/doador.service';
import { RacaService } from './../../service/raca.service';
import { EspecieService } from './../../service/especie.service';
import { AlertService } from '@full-fledged/alerts';
import { Animal } from './../../models/animal.model';
import { AnimalService } from './../../service/animal.service';
import { Component, OnInit } from '@angular/core';
import { base64StringToBlob } from 'blob-util';
import { DomSanitizer } from '@angular/platform-browser';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-filter',
  templateUrl: './filter.component.html',
  styleUrls: ['./filter.component.scss'],
})
export class FilterComponent implements OnInit {
  loading = true;
  reader = new FileReader();
  animal: Animal[] = [];
  person;
  filterId;
  image: any;
  contentType = 'image/png';
  idAnimalAtual = 0;
  animalAtual;
  animaisNaoAdotados;
  constructor(
    private animalService: AnimalService,
    private alertService: AlertService,
    private router: ActivatedRoute,
    private route: Router,
    private especieService: EspecieService,
    private doadorService: DoadorService,
    private adotanteService: AdotanteService,
    private racaService: RacaService,
    private porteService: PorteService
  ) {}

  ngOnInit(): void {
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    if (json !== '') {
      this.person = json.pessoa;
    } else {
      this.alertService.danger('Você não tem permissãao! Faça o login.');
      this.route.navigate(['/home']);
    }
    this.filterId = this.router.snapshot.params['id'];
    this.animalsFilter();
    this.getPorte();
  }
  next() {
    this.idAnimalAtual++;

    this.animalAtual = this.animal[this.idAnimalAtual];
  }
  prev() {
    this.idAnimalAtual--;

    this.animalAtual = this.animal[this.idAnimalAtual];
  }

  getEspecies(idEspecie: any, index: number) {
    this.especieService
      .retrieveEspecieById(idEspecie)
      .pipe()
      .subscribe(
        (res) => {
          this.animal[index].nome_especie = res.nome;
        },
        (err) => {
          this.alertService.danger('Erro ao retornar as especies!');
        }
      );
  }
  getRaca() {
    this.racaService
      .retrieveRacas()
      .pipe()
      .subscribe(
        (res) => {
          this.animal.forEach((ani, index) => {
            var raca = res.find((a) => a.id_raca == ani.id_raca);
            ani.nome_raca = raca?.nome;
            this.getEspecies(raca?.id_especie, index);
          });
        },
        (err) => {
          this.alertService.danger('Erro ao retornar a raça!');
        }
      );
  }

  getPorte() {
    this.porteService
      .retrievePorte()
      .pipe()
      .subscribe(
        (res) => {
          this.animal.forEach((ani) => {
            var porte = res.find((x) => x.id_porte === ani.id_porte);
            ani.nome_porte = porte?.nome;
          });
        },
        (err) => {
          this.alertService.danger('Erro ao retornar os portes!');
        }
      );
  }
  getDonor() {
    this.animal.forEach((ani) => {
      this.doadorService
        .getDoador(ani.id_doador)
        .pipe()
        .subscribe(
          (res) => {
            ani.doador = res;
            this.loading = false;
          },
          (err) => {
            this.alertService.danger('Erro ao retornar Doador!');
          }
        );
    });
  }
  animalsFilter() {
    this.animalService
      .retrieveFilter(this.filterId)
      .pipe()
      .subscribe(
        (res) => {
          this.animal = res;
          if (this.animal.length > 0) {
            this.getRaca();
            this.getDonor();
            this.animal.forEach((element, index) => {
              if (element.adotado) {
                this.animal.splice(index, 1);
              }
            });
            this.animalAtual = this.animal[0];
          }
        },
        (err) => {
          this.alertService.danger('Erro ao retornar o filtro de animais!');
        }
      );
  }
  adoptAnimal(animal: Animal, idAnimal: number) {
    if (window.confirm('Você deseja realmente adotar este animalzinho?')) {
      this.loading = true;
      const body = {
        id_animal: idAnimal,
        id_adotante: this.person.id_adotante,
        id_doador: animal.id_doador,
      };
      this.adotanteService
        .adoptAnimal(body)
        .pipe()
        .subscribe(
          (res) => {
            this.loading = false;
            this.animalsFilter();
            this.alertService.success(
              'Parabens pelo novo animalzinho! Será enviado as informações no email'
            );
          },
          (err) => {
            this.alertService.danger('Erro ao adotar o animal!');
          }
        );
    }
  }
  antoherFilter() {
    this.route.navigate(['./pesquisa']);
  }
}
