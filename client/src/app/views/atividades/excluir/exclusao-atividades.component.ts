import { NgForOf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatTooltipModule } from '@angular/material/tooltip';
import { RouterLink, ActivatedRoute, Router } from '@angular/router';
import { NotificacaoService } from '../../../core/notificacao/notificacao.service';
import { VisualizarAtividadeViewModel } from '../models/atividade.models';
import { tipoAtividadeEnum } from '../models/tipoAtividadeEnum';
import { AtividadeService } from '../services/atividades.service';

@Component({
  selector: 'app-exclusao-atividades',
  standalone: true,
  imports: [
    NgForOf,
    RouterLink,
    MatCardModule,
    MatIconModule,
    MatButtonModule,
    MatTooltipModule,
  ],
  templateUrl: './exclusao-atividades.component.html',
})
export class ExclusaoAtividadesComponent implements OnInit {
  Atividade?: VisualizarAtividadeViewModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private AtividadeService: AtividadeService,
    private notificacao: NotificacaoService
  ) {}

  ngOnInit(): void {
    this.Atividade = this.route.snapshot.data['atividade'];

    console.log(this.Atividade);
  }

  excluir() {
    if (!this.Atividade?.id) {
      this.notificacao.erro('Não foi possível recuperar o id requisitado!');

      return;
    }

    this.AtividadeService.excluir(this.Atividade?.id).subscribe((res) => {
      this.notificacao.sucesso(
        `O registro ID [${this.Atividade?.id}] foi excluído com sucesso!`
      );

      this.router.navigate(['/atividades']);
    });
  }
  public obterTextoTipoAtividade(tipo: tipoAtividadeEnum | undefined): string {
    return tipoAtividadeEnum[Number(tipo)];
  }
  public formatarData(data: Date | undefined): string | null {
    var date = new Date(data!);
    var [ano, mes, dia] = date.toISOString().split('T')[0].split('-');
    return `${dia}/${mes}/${ano}`;
  }
}
