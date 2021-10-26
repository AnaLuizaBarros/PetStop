import { Component, OnInit } from '@angular/core';
import { Pessoa } from 'src/app/models/pessoa.model';

@Component({
  selector: 'app-side-bar',
  templateUrl: './side-bar.component.html',
  styleUrls: ['./side-bar.component.scss'],
})
export class SideBarComponent implements OnInit {
  person;
  name;
  constructor() {
    // console.log(JSON.parse(localStorage.getItem('pessoa') || ''));
    var json = JSON.parse(localStorage.getItem('usuario') || '');
    this.person = json.pessoa;
    var split = this.person.nome.split(' ');
    this.name = split[1] ? split[1] : split[0];
    console.log(this.name);
  }

  ngOnInit(): void {}
}
