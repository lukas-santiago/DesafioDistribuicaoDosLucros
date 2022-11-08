export type ConfiguracaoCalculo = {
  id: number
  creationDate: string
  updatedDate: string
  ativo: boolean
  valorTotalDisponibilizado: number
  salarioMinimo: number
}

export type Funcionario = {
  id: number
  creationDate: Date
  updatedDate: Date
  ativo: boolean
  matricula: string
  nome: string
  areaAtuacao: number
  cargo: number
  salarioBruto: number
  dataAdmissao: Date
}
