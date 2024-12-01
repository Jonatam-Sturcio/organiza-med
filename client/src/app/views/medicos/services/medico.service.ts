import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { catchError, map, Observable, tap, throwError } from 'rxjs';

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
    return this.http.post<MedicoInseridoViewModel>(this.url, novoMedico).pipe(
      map((x) => this.processarRes(x) as MedicoInseridoViewModel),
      catchError(this.processarFalha)
    );
  }

  editar(
    id: string,
    MedicoEditado: EdicaoMedicoViewModel
  ): Observable<MedicoEditadoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http
      .put<MedicoEditadoViewModel>(urlCompleto, MedicoEditado)
      .pipe(
        map((x) => this.processarRes(x) as MedicoEditadoViewModel),
        catchError(this.processarFalha)
      );
  }

  excluir(id: string): Observable<MedicoExcluidoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<MedicoExcluidoViewModel>(urlCompleto);
  }

  selecionarTodos(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}?maisAtividades=false`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto).pipe(
      map((x) => this.processarRes(x) as ListarMedicoViewModel[]),
      catchError(this.processarFalha)
    );
  }
  selecionarTodosOrdenados(): Observable<ListarMedicoViewModel[]> {
    const urlCompleto = `${this.url}?maisAtividades=true`;
    return this.http.get<ListarMedicoViewModel[]>(urlCompleto).pipe(
      map((x) => this.processarRes(x) as ListarMedicoViewModel[]),
      catchError(this.processarFalha)
    );
  }
  selecionarPorId(id: string): Observable<VisualizarMedicoViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarMedicoViewModel>(urlCompleto).pipe(
      map((x) => this.processarRes(x) as VisualizarMedicoViewModel),
      catchError(this.processarFalha)
    );
  }

  private processarRes(res: any): any {
    return res.dados;
  }
  private processarFalha(resposta: any) {
    return throwError(() => new Error(resposta.error.erros[0]));
  }
}
