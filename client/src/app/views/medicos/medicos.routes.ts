import { Routes } from '@angular/router';
import { ListagemMedicosComponent } from './listar/listagem-medicos.component';
import { CadastroMedicoComponent } from './cadastrar/cadastro-medico.component';

export const MedicosRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemMedicosComponent },
  { path: 'cadastrar', component: CadastroMedicoComponent },
];
