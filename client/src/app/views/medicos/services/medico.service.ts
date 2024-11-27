import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { environment } from '../../../../environments/environment';
import {
  InserirMedicoViewModel,
  MedicoInseridoViewModel,
  EdicaoMedicoViewModel,
  MedicoEditadoViewModel,
  MedicoExcluidoViewModel,
  ListarMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../models/medico.models';

@Injectable({
  providedIn: 'root',
})
export class MedicoService {
  private readonly url = `${environment.apiUrl}/Medicos`;

  constructor(private http: HttpClient) {}

  cadastrar(
    novoMedico: InserirMedicoViewModel
  ): Observable<MedicoInseridoViewModel> {
    return this.http.post<MedicoInseridoViewModel>(this.url, novoMedico);
  }

  editar(
    id: string,
    MedicoEditado: EdicaoMedicoViewModel
  ): Observable<MedicoEditadoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.put<MedicoEditadoViewModel>(urlCompleto, MedicoEditado);
  }

  excluir(id: string): Observable<MedicoExcluidoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<MedicoExcluidoViewModel>(urlCompleto);
  }

  selecionarTodos(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}/?maisAtividades=false`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto);
  }

  selecionarTodosOrdenado(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}/?maisAtividades=true`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto);
  }

  selecionarPorId(id: string): Observable<VisualizarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarMedicoViewModel>(urlCompleto);
  }
}
