import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CadastroDoadorComponent } from '../cadastroDoador/cadastro.doador.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss'],
})
export class HomeComponent implements OnInit {
  constructor(private router: Router, 
  private route: ActivatedRoute,
  private cadastroComponent: CadastroDoadorComponent) {}

  ngOnInit(): void {}
  registration(type: string) {
    console.log(type);
    if (type == 'adotante') {
      this.router.navigate(['/cadastroAdotante']);
    }
    if (type == 'doador') {
      this.router.navigate(['/cadastroDoador']);
    }
    //this.router.navigate(['/cadastroDoador']);
    //this.cadastroComponent.getOption(type);
    //this.cadastroComponent.option = type;
  }
}
