import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { catchError, map, Observable, tap, throwError } from 'rxjs';

import { environment } from '../../../../environments/environment';
import {
  InserirAtividadeViewModel,
  AtividadeInseridaViewModel,
  EdicaoAtividadeViewModel,
  AtividadeEditadaViewModel,
  AtividadeExcluidaViewModel,
  ListarAtividadeViewModel,
  VisualizarAtividadeViewModel,
} from '../models/atividade.models';

@Injectable({
  providedIn: 'root',
})
export class AtividadeService {
  private readonly url = `${environment.apiUrl}/Atividades`;

  constructor(private http: HttpClient) {}

  cadastrar(
    novoAtividade: InserirAtividadeViewModel
  ): Observable<AtividadeInseridaViewModel> {
    return this.http
      .post<AtividadeInseridaViewModel>(this.url, novoAtividade)
      .pipe(
        map((x) => this.processarRes(x) as AtividadeInseridaViewModel),
        catchError(this.processarFalha)
      );
  }

  editar(
    id: string,
    AtividadeEditado: EdicaoAtividadeViewModel
  ): Observable<AtividadeEditadaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http
      .put<AtividadeEditadaViewModel>(urlCompleto, AtividadeEditado)
      .pipe(
        map((x) => this.processarRes(x) as AtividadeEditadaViewModel),
        catchError(this.processarFalha)
      );
  }

  excluir(id: string): Observable<AtividadeExcluidaViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.delete<AtividadeExcluidaViewModel>(urlCompleto);
  }

  selecionarTodos(): Observable<ListarAtividadeViewModel[]> {
    return this.http.get<ListarAtividadeViewModel[]>(this.url).pipe(
      map((x) => this.processarRes(x) as ListarAtividadeViewModel[]),
      catchError(this.processarFalha)
    );
  }

  selecionarPorId(id: string): Observable<VisualizarAtividadeViewModel> {
    const urlCompleto = `${this.url}/${id}`;

    return this.http.get<VisualizarAtividadeViewModel>(urlCompleto).pipe(
      map((x) => this.processarRes(x) as VisualizarAtividadeViewModel),
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
