export type ConfiguracaoCalculo = BaseModel & {
  id: number
  creationDate: string
  updatedDate: string
  ativo: boolean
  valorTotalDisponibilizado: number
  salarioMinimo: number
}

export type Funcionario = BaseModel & {
  matricula: string
  nome: string
  areaAtuacao: number
  cargo: number
  salarioBruto: number
  dataAdmissao: Date
}

export type RelatorioDistribuicao = BaseModel & {
  totalDisponibilizado: number
  totalDistribuido: number
  salarioMinimo: number
  saldoDisponibilizadoDistribuido: number
  relatorioDistribuicaoFuncionario: RelatorioDistribuicaoFuncionario[]
  totalFuncionarios: number
  relatorioDistribuicaoPeso: RelatorioDistribuicaoPeso[]
}

export type RelatorioDistribuicaoFuncionario = BaseModel & {
  matricula: string
  nome: string
  areaAtuacao: number
  dataAdmissao: string
  cargo: number
  salarioBruto: number
  valorDisponibilizado: number
  valorTotal: number
  relatorioDistribuicaoId: number
  relatorioDistribuicao: RelatorioDistribuicao
}

export type RelatorioDistribuicaoPeso = Peso & {
  relatorioDistribuicaoId: number
  relatorioDistribuicao: RelatorioDistribuicao | null
}

export type Peso = BaseModel & {
  tipoPeso: string
  valor: number
  nome: string
  valorMaximo: number
  valorMinimo: number
  funcionarios: Funcionario[]
}

export type BaseModel = {
  id: number
  creationDate: Date | string
  updatedDate: Date | string
  ativo: boolean
}
