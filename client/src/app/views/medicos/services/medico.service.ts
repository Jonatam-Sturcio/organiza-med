import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { map, Observable, tap } from 'rxjs';

import {
  InserirMedicoViewModel,
  MedicoInseridoViewModel,
  EdicaoMedicoViewModel,
  MedicoEditadoViewModel,
  MedicoExcluidoViewModel,
  ListarMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../models/medico.models';
import { environment } from '../../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class MedicoService {
  private readonly url = `${environment.apiUrl}/medicos`;

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
    const urlCompleto = `${this.url}?maisAtividades=false`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto).pipe(
      map((x) => this.processarRes(x) as ListarMedicoViewModel[]),
      tap((x) => console.log(x))
    );
  }

  selecionarTodosOrdenado(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}?maisAtividades=true`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto);
  }

  selecionarPorId(id: string): Observable<VisualizarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarMedicoViewModel>(urlCompleto);
  }

  private processarRes(res: any): any {
    return res.dados;
  }
}
