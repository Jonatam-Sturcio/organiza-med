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
    return this.http
      .post<MedicoInseridoViewModel>(this.url, novoMedico)
      .pipe(map((x) => this.processarRes(x) as MedicoInseridoViewModel));
  }

  editar(
    id: string,
    MedicoEditado: EdicaoMedicoViewModel
  ): Observable<MedicoEditadoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http
      .put<MedicoEditadoViewModel>(urlCompleto, MedicoEditado)
      .pipe(map((x) => this.processarRes(x) as MedicoEditadoViewModel));
  }

  excluir(id: string): Observable<MedicoExcluidoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http
      .delete<MedicoExcluidoViewModel>(urlCompleto)
      .pipe(map((x) => this.processarRes(x) as MedicoExcluidoViewModel));
  }

  selecionarTodos(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}?maisAtividades=false`;
    return this.http
      .get<ListarMedicoViewModel[]>(urlCompleto)
      .pipe(map((x) => this.processarRes(x) as ListarMedicoViewModel[]));
  }

  selecionarPorId(id: string): Observable<VisualizarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http
      .get<VisualizarMedicoViewModel>(urlCompleto)
      .pipe(map((x) => this.processarRes(x) as VisualizarMedicoViewModel));
  }

  private processarRes(res: any): any {
    return res.dados;
  }
}
