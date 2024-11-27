import { Routes } from '@angular/router';
import { ListagemMedicosComponent } from './listar/listagem-medicos.component';
import { CadastroMedicoComponent } from './cadastrar/cadastro-medico.component';
import { ExclusaoMedicoComponent } from './excluir/exclusao-medico.component';
import { EdicaoMedicoComponent } from './editar/edicao-medico.component';

export const MedicosRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemMedicosComponent },
  { path: 'cadastrar', component: CadastroMedicoComponent },
  { path: 'editar/:id', component: EdicaoMedicoComponent },
  { path: 'excluir/:id', component: ExclusaoMedicoComponent },
];
