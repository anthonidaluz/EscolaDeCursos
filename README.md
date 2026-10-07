# Escola de Cursos

## Projeto

Desenvolvido durante o curso Fullstack da [Academia do Programador](https://www.academiadoprogramador.net) 2026

Uma escola de cursos profissionalizantes oferece diversas formações presenciais e online para alunos que desejam desenvolver novas habilidades e ingressar no mercado de trabalho.

Os alunos da Academia do Programador foram contratados para desenvolver um aplicativo web responsável por gerenciar toda a estrutura acadêmica da escola, permitindo a gestão das informações de cursos, instrutores, turmas e matrículas.

## Funcionalidades

### 1. Módulo de Alunos

#### Requisitos Funcionais

- O sistema deve permitir registrar novos alunos.
- O sistema deve permitir visualizar todos os alunos cadastrados.
- O sistema deve permitir editar alunos existentes.
- O sistema deve permitir excluir alunos cadastrados.

#### Regras de Negócio

- Campos obrigatórios:
  - Nome (3-100 caracteres)
  - Email (válido)
  - CPF (11 dígitos)
- O sistema não deve permitir o cadastro de alunos com o mesmo CPF.
- O número de matrícula do aluno é gerado automaticamente no cadastro (formato ALU-XXXXXXXX).
- O sistema não deve permitir a exclusão de alunos que possuem matrículas.

### 2. Módulo de Instrutores

#### Requisitos Funcionais

- O sistema deve permitir registrar novos instrutores.
- O sistema deve permitir visualizar todos os instrutores cadastrados.
- O sistema deve permitir editar instrutores existentes.
- O sistema deve permitir excluir instrutores cadastrados.

#### Regras de Negócio

- Campos obrigatórios:
  - Nome (3-100 caracteres)
  - Telefone (formatos válidos: (XX) XXXX-XXXX ou (XX) XXXXX-XXXX)
  - CPF (11 dígitos)
- O sistema não deve permitir o cadastro de instrutores com o mesmo nome, telefone ou CPF.
- O sistema não deve permitir a exclusão de instrutores vinculados a turmas.

### 3. Módulo de Cursos e Aulas

#### Requisitos Funcionais

- O sistema deve permitir registrar novos cursos.
- O sistema deve permitir visualizar todos os cursos cadastrados.
- O sistema deve permitir editar cursos existentes.
- O sistema deve permitir excluir cursos cadastrados.
- O sistema deve permitir gerenciar as aulas de um curso (adicionar, editar e remover).

#### Regras de Negócio

- Campos obrigatórios do curso:
  - Nome (2-100 caracteres)
  - Nível (Iniciante, Intermediário ou Avançado)
  - Carga horária (2-100 horas)
- Campos obrigatórios da aula:
  - Nome (2-100 caracteres)
  - Duração em minutos (não pode ser negativa)
  - Ordem
- O sistema não deve permitir o cadastro de cursos com o mesmo nome.
- O sistema não deve permitir aulas com o mesmo nome ou com a mesma ordem dentro de um curso.
- O sistema não deve permitir a exclusão de cursos que possuem aulas cadastradas ou turmas vinculadas.

### 4. Módulo de Turmas

#### Requisitos Funcionais

- O sistema deve permitir registrar novas turmas.
- O sistema deve permitir visualizar todas as turmas cadastradas, com a quantidade de matrículas.
- O sistema deve permitir editar turmas existentes.
- O sistema deve permitir excluir turmas cadastradas.

#### Regras de Negócio

- Campos obrigatórios:
  - Nome (2-100 caracteres)
  - Curso
  - Instrutor
  - Número máximo de alunos (1-100)
  - Data de início
  - Data de término (posterior à data de início)
- O sistema não deve permitir reduzir o número máximo de alunos abaixo da quantidade de matrículas atuais.
- O sistema não deve permitir a exclusão de turmas que possuem matrículas.

### 5. Módulo de Matrículas

#### Requisitos Funcionais

- O sistema deve permitir registrar novas matrículas.
- O sistema deve permitir visualizar todas as matrículas cadastradas.
- O sistema deve permitir editar matrículas existentes.
- O sistema deve permitir excluir matrículas cadastradas.

#### Regras de Negócio

- Campos obrigatórios:
  - Aluno
  - Turma
- O sistema não deve permitir matricular o mesmo aluno mais de uma vez na mesma turma.
- O sistema não deve permitir matrículas em turmas que atingiram o número máximo de alunos.

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

   ```bash
   dotnet restore
   ```

4. Para executar o projeto compilando em tempo real

   ```bash
   dotnet run --project WebApp/EscolaDeCursos.WebApp.csproj
   ```

## Requisitos

- .NET 10.0 SDK
