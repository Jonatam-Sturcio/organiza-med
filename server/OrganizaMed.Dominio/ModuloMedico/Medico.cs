﻿using OrganizaMed.Dominio.Compartilhado;

namespace OrganizaMed.Dominio.ModuloMedico;

public class Medico : Entidade
{
	public Medico()
	{
	}

	public Medico(string nome, string especialidade, string Crm)
	{
		Nome = nome;
		Especialidade = especialidade;
		CRM = Crm;
		Atividades = [];
	}

	public string Nome { get; set; }
	public string Especialidade { get; set; }
	public string CRM { get; set; }

	public List<AtividadeBase> Atividades { get; set; }

	public override string ToString()
	{
		return $"Nome: {Nome} | CRM: {CRM}";
	}

	public bool HorarioAtividadeEstaValido(AtividadeBase atividade)
	{
		var periodoDeDescansoValido = true;

		foreach (var atividadeRegistrada in Atividades)
		{
			if (atividadeRegistrada.Id == atividade.Id)
				continue;

			TimeSpan diferencial;

			if (atividade.HoraInicio > atividadeRegistrada.HoraTermino)
				diferencial = atividade.HoraInicio.Subtract(atividadeRegistrada.HoraTermino);
			else
				diferencial = atividadeRegistrada.HoraInicio.Subtract(atividade.HoraTermino);

			if (diferencial <= atividadeRegistrada.ObterPeriodoDescanso())
				periodoDeDescansoValido = false;
		}
		return periodoDeDescansoValido;
	}

	public void RegistrarAtividade(AtividadeBase atividade)
	{
		foreach (var atividadeRegistrada in Atividades)
		{
			if (atividadeRegistrada.Id == atividade.Id)
				continue;
		}
		Atividades.Add(atividade);
	}
}