import { NgIf, NgForOf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  FormArray,
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatNativeDateModule } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { ActivatedRoute, Router, RouterLink } from '@angular/router';
import {
  AtividadeEditadaViewModel,
  EdicaoAtividadeViewModel,
  VisualizarAtividadeViewModel,
} from '../models/atividade.models';
import { AtividadeService } from '../services/atividades.service';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';
import {
  ListarMedicoViewModel,
  EdicaoMedicoViewModel,
} from '../../medicos/models/medico.models';
import { tipoAtividadeEnum } from '../models/tipoAtividadeEnum';

@Component({
  selector: 'app-edicao-atividades',
  standalone: true,
  imports: [
    NgIf,
    NgForOf,
    RouterLink,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
    MatNativeDateModule,
    MatDatepickerModule,
    MatSelectModule,
  ],
  templateUrl: './edicao-atividades.component.html',
})
export class EdicaoAtividadesComponent implements OnInit {
  id?: string;
  AtividadeForm: FormGroup;
  public medicos: ListarMedicoViewModel[] = [];

  public opcaoAtividade = Object.values(tipoAtividadeEnum).filter(
    (v) => !Number.isFinite(v)
  );

  constructor(
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private AtividadeService: AtividadeService,
    private notificacao: NotificacaoService
  ) {
    this.AtividadeForm = this.fb.group({
      data: [, [Validators.required]],
      horaInicio: ['', Validators.required],
      horaTermino: ['', Validators.required],
      tipoAtividade: [0, [Validators.required]],
      medicosId: [],
    });
  }

  get data() {
    return this.AtividadeForm.get('data');
  }
  get horaInicio() {
    return this.AtividadeForm.get('horaInicio');
  }
  get horaTermino() {
    return this.AtividadeForm.get('horaTermino');
  }
  get tipoAtividade() {
    return this.AtividadeForm.get('tipoAtividade');
  }
  get medicosSelecionados() {
    return this.AtividadeForm.get('medicosSelecionados') as FormArray;
  }

  ngOnInit(): void {
    this.medicos = this.route.snapshot.data['medicos'];
    this.id = this.route.snapshot.params['id'];
    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }

    this.AtividadeService.selecionarPorId(this.id).subscribe((res) =>
      this.carregarFormulario(res)
    );
  }

  editar() {
    if (this.AtividadeForm.invalid) return;

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    const novaAtividade: EdicaoAtividadeViewModel = this.AtividadeForm.value;

    novaAtividade.horaInicio = this.obterDataHora('horaInicio');

    novaAtividade.horaTermino = this.obterDataHora('horaTermino');

    this.AtividadeService.editar(this.id, novaAtividade).subscribe({
      next: (atividadeEditado) => this.processarSucesso(atividadeEditado),
      error: (erro) => this.processarFalha(erro),
    });
  }

  private obterDataHora(horaAtividade: any): Date {
    const data = this.AtividadeForm.get('data')?.value;
    const hora = this.AtividadeForm.get(horaAtividade)?.value;

    const dataObj = new Date(data);

    const [horaParte, minutoParte] = hora.split(':').map(Number);
    dataObj.setHours(horaParte - 6, minutoParte, 0, 0);
    return dataObj;
  }

  private carregarFormulario(registro: VisualizarAtividadeViewModel) {
    var dataI = new Date(registro.horaInicio);
    var dataT = new Date(registro.horaTermino);
    dataI.setDate(dataI.getDate() + 1);

    this.AtividadeForm.patchValue({
      tipoAtividade: registro.tipoAtividade,
      data: dataI.toISOString().split('T')[0],
      horaInicio: dataI.toISOString().split('T')[1].split('.')[0],
      horaTermino: dataT.toISOString().split('T')[1].split('.')[0],
      medicosId: registro.medicos.map((m: ListarMedicoViewModel) => m.id),
    });
  }

  private processarSucesso(registro: AtividadeEditadaViewModel): void {
    this.notificacao.sucesso(`Atividade "${registro.id}" editada com sucesso!`);

    this.router.navigate(['/atividades', 'listar']);
  }

  private processarFalha(erro: Error) {
    this.notificacao.erro(erro.message);
  }
}
