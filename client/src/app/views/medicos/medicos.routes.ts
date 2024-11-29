import { ActivatedRouteSnapshot, ResolveFn, Routes } from '@angular/router';
import { ListagemMedicosComponent } from './listar/listagem-medicos.component';
import { CadastroMedicoComponent } from './cadastrar/cadastro-medico.component';
import { ExclusaoMedicoComponent } from './excluir/exclusao-medico.component';
import { EdicaoMedicoComponent } from './editar/edicao-medico.component';
import { inject } from '@angular/core';
import { VisualizarMedicoViewModel } from './models/medico.models';
import { MedicoService } from './services/medico.service';
import { DetalhesMedicoComponent } from './visualizar/detalhes-medico.component';

const visualizarMedicosResolver: ResolveFn<VisualizarMedicoViewModel> = (
  route: ActivatedRouteSnapshot
) => {
  const id = route.params['id'];
  return inject(MedicoService).selecionarPorId(id);
};

export const MedicosRoutes: Routes = [
  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'listar', component: ListagemMedicosComponent },
  { path: 'cadastrar', component: CadastroMedicoComponent },
  { path: 'editar/:id', component: EdicaoMedicoComponent },
  {
    path: 'excluir/:id',
    component: ExclusaoMedicoComponent,
    resolve: { medico: visualizarMedicosResolver },
  },
  {
    path: 'visualizar/:id',
    component: DetalhesMedicoComponent,
    resolve: {
      medico: visualizarMedicosResolver,
    },
  },
];
