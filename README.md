# NoteKeeper

[![Stack](https://skillicons.dev/icons?i=dotnet,cs,cypress,azure,nodejs,typescript,angular&perline=8)](https://skillicons.dev)

## Projeto

Desenvolvido durante o curso Full-Stack da [Academia do Programador](https://www.academiadoprogramador.net) 2024

---
## Descrição

Uma clínica médica é um centro onde atividades, como cirurgias e consultas, são realizadas por profissionais médicos.
Os alunos da Academia do Programador 2024 foram contratados para criar um aplicativo web que mantenha e
organize o cronograma dessas atividades dentro da clínica.

Cada médico é identificado pelo CRM que é composto por cinco dígitos e a sigla do estado (78806-SP).

As atividades dos médicos têm um horário de início e término e existem dois tipos diferentes de atividades, vejamos:

	• Realizar Consulta: Sempre realizada por um único médico.
	• Realizar Cirurgia: Pode ser realizada por um médico individualmente ou por uma equipe de médicos.

Os médicos podem realizar atividades durante o dia inteiro, em todos os dias do ano. No entanto, cada vez que um
médico termina uma atividade, é necessário um tempo de descanso para recuperação. Independentemente da duração
da atividade, o período de recuperação será de 4 horas após realizar uma cirurgia e 10 minutos após realizar uma
consulta médica.

**Escopo da Solução**

	• O aplicativo deve permitir agendar atividades em qualquer momento (futuro ou passado).
	• Quando uma atividade é criada, deve ser possível indicar os horários de início e término, o tipo de atividade e o
	médico (ou lista de médicos) que está realizando essa atividade.

**Diversão Opcional? Não é obrigatório, mas você pode ampliar o escopo da solução com alguns dos pontos abaixo:**

	• É possível modificar os horários de uma atividade existente.
	• É possível excluir uma atividade existente.
	• O aplicativo indica quando a atividade de um médico entra em conflito com outras atividades do mesmo médico,
	devido à sobreposição de horários.
	• Esses conflitos ajudarão os usuários do aplicativo a ajustarem os horários das atividades para que o problema
	possa ser resolvido.
	• O aplicativo mostra uma lista dos 10 médicos que mais horas trabalharam dentro de um período.


---
## Funcionalidades

1. O cadastro do **Médico** consiste de:
    - Nome
    - CRM
    - Especialidade

2. O cadastro do **Atividades** consiste de:
	- Tipo da Atividade
	- Data/Hora de Inicio
	- Data/Hora de Termino  
	- Medicos

---
## Requisitos para Execução do Projeto Completo

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto back-end.
- Node.js v20+
- Angular v18 

---
## Executando o Back-End 

Vá para a pasta do projeto da WebAPI:

```bash
cd server/OrganizaMed.WebApi
```

Execute o projeto:

```bash
dotnet run
```

A API poderá ser acessada no endereço `https://localhost:8000/api`.

A documentação **OpenAPI** também estará disponível em: `https://localhost:8000/swagger`.

---
## Executando o Front-End 

Vá para a pasta do projeto Angular:

```bash
cd client
```

Instale as dependências:

```bash
npm install
```

Execute o projeto:

```bash
npm start
```

A aplicação Angular estárá disponível no endereço `http://localhost:4200`.
