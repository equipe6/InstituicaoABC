import { Component } from '@angular/core';
import { StoreService } from '../../store.service';
import { faHome, faUserGraduate, faUsers, faSyringe, faFileSignature, faMoneyBillWave } from '@fortawesome/free-solid-svg-icons';
import { AlunoDataService } from 'src/app/_data-services/aluno.data-service';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  faHome = faHome;
  faUserGraduate = faUserGraduate;
  faUsers = faUsers;
  faSyringe = faSyringe;
  faFileSignature = faFileSignature;
  faMoneyBillWave = faMoneyBillWave;

  sistema: string = 'gestao';
  modulo: string = 'home';
  titulo: string = 'Home';

  totalAlunos: any = 0;
  totalContratos: any = 0;
  totalPagamentos: any = 0;

  usuarioLogado: any = {};

  constructor(
    private store: StoreService,
    private alunoDataService: AlunoDataService
    // private internoDataService: InternoDataService,
    // private anamneseDataService: AnamneseDataService,
    // private checklistDataService: ChecklistDataService
  ) {
    this.usuarioLogado = store._usuarioLogado;
    this.alunoDataService = alunoDataService;
  }

  ngOnInit() {
    this.getAlunos();
    this.getContratos();
    this.getPagamentos();
  }

  getAlunos() {
    this.alunoDataService.getAll().subscribe((data:any[]) => {
      this.totalAlunos = data.length;
    }, error => {
      console.log(error);
    });
  }

  getContratos() {
    // this.anamneseDataService.getAll().subscribe((data:any[]) => {
    //   this.totalContratos = data.length;
    // }, error => {
    //   console.log(error);
    // });
  }

  getPagamentos() {
    // this.checklistDataService.getAll().subscribe((data:any[]) => {
    //   this.totalPagamentos = data.length;
    // }, error => {
    //   console.log(error);
    // });
  }

}
