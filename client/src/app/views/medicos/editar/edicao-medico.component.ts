import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import {
  ReactiveFormsModule,
  FormGroup,
  FormControl,
  Validators,
} from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { RouterLink, Router, ActivatedRoute } from '@angular/router';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';
import {
  EdicaoMedicoViewModel,
  InserirMedicoViewModel,
  VisualizarMedicoViewModel,
} from '../models/medico.models';
import { ValidadorCustomizadoCRM } from '../Validator/ValidadorCustomizado';
import { MedicoService } from '../services/medico.service';

@Component({
  selector: 'app-edicao-medico',
  standalone: true,
  imports: [
    NgIf,
    RouterLink,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatIconModule,
    MatButtonModule,
  ],
  templateUrl: './edicao-medico.component.html',
})
export class EdicaoMedicoComponent implements OnInit {
  id?: string;
  MedicoForm: FormGroup;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private MedicoService: MedicoService,
    private notificacao: NotificacaoService
  ) {
    this.MedicoForm = new FormGroup({
      nome: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(3),
      ]),
      crm: new FormControl<string>('', [
        Validators.required,
        ValidadorCustomizadoCRM(/^\d{5}-[A-Z]{2}$/),
      ]),
      especialidade: new FormControl<string>('', [
        Validators.required,
        Validators.minLength(3),
      ]),
    });
  }

  get nome() {
    return this.MedicoForm.get('nome');
  }
  get crm() {
    return this.MedicoForm.get('crm');
  }
  get especialidade() {
    return this.MedicoForm.get('especialidade');
  }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');
      return;
    }
    this.MedicoService.selecionarPorId(this.id).subscribe((res) =>
      this.carregarFormulario(res)
    );
  }

  editar() {
    if (this.MedicoForm.invalid) return;

    if (!this.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    const novoMedico: EdicaoMedicoViewModel = this.MedicoForm.value;

    this.MedicoService.editar(this.id, novoMedico).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${res.id}] foi cadastrado com sucesso!`
      );

      this.router.navigate(['/medicos']);
    });
  }

  private carregarFormulario(registro: VisualizarMedicoViewModel) {
    this.MedicoForm.patchValue(registro);
  }
}
