import axios from 'axios'
import React, { useEffect, useMemo, useState } from 'react'
import { Container, Button } from 'react-bootstrap'
import { useNavigate, useParams } from 'react-router-dom'
import { Column } from 'react-table'
import { ErrorBoundary } from '../../components/ErrorBoundary'
import { GenericTable } from '../../components/GenericTable'
import {
  RelatorioDistribuicao,
  RelatorioDistribuicaoFuncionario,
} from '../../types/types'

export function RelatorioDistribuicaoDetailsRoute() {
  let { id } = useParams()
  const navigate = useNavigate()

  const [rowDataState, setRowDataState] = useState<RelatorioDistribuicao>()

  const parseToDateTimeCell = function parseToDateTimeCell():
    | (({ cell }: any) => JSX.Element)
    | undefined {
    return ({ cell }: any) => (
      <div>
        {new Date(cell.value).toLocaleString('pt-br', {
          dateStyle: 'short',
          timeStyle: 'short',
        })}
      </div>
    )
  }
  const columnsRelatorioDistribuicao: Column<RelatorioDistribuicao>[] = useMemo(
    () => [
      { header: '#', accessor: 'id' },
      { header: 'Total Disponibilizado', accessor: 'totalDisponibilizado' },
      { header: 'Total Distribuído', accessor: 'totalDistribuido' },
      { header: 'Salario Mínimo', accessor: 'salarioMinimo' },
      {
        header: 'Disponibilizado - Distribuído',
        accessor: 'saldoDisponibilizadoDistribuido',
      },
      { header: 'Total de Funcionários', accessor: 'totalFuncionarios' },
      {
        header: 'Criado em',
        accessor: 'creationDate',
        Cell: parseToDateTimeCell(),
      },
      {
        header: 'Atualizado em',
        accessor: 'updatedDate',
        Cell: parseToDateTimeCell(),
      },
    ],
    [],
  )
  const rowDataRelatorioDistribuicao = useMemo(
    () => (rowDataState ? [...[rowDataState]] : []),
    [rowDataState],
  )
  const columnsRelatorioDistribuicaoFuncionario: Column<
    RelatorioDistribuicaoFuncionario
  >[] = useMemo(
    () => [
      { header: '#', accessor: 'id' },
      { header: 'Matrícula', accessor: 'matricula' },
      { header: 'Nome', accessor: 'nome' },
      { header: 'Área de Atuação', accessor: 'areaAtuacao' },
      { header: 'Data de Admissão', accessor: 'dataAdmissao', Cell: parseToDateTimeCell() },
      { header: 'Cargo', accessor: 'cargo' },
      { header: 'Salário Bruto', accessor: 'salarioBruto' },
      { header: 'Valor Disponibilizado', accessor: 'valorDisponibilizado' },
      { header: 'Valor Total', accessor: 'valorTotal' },
    ],
    [],
  )
  const rowDataRelatorioDistribuicaoFuncionario = useMemo(
    () =>
      rowDataState?.relatorioDistribuicaoFuncionario
        ? [...rowDataState?.relatorioDistribuicaoFuncionario]
        : [],
    [rowDataState],
  )

  const fetchData = async () => {
    try {
      const response = await axios.get(
        'http://localhost:5216/api/v1/RelatorioDistribuicao/' + Number(id),
      )
      setRowDataState(response.data)
    } catch (error) {
      console.error(error)
    }
  }
  useEffect(() => {
    fetchData()
  }, [])
  return (
    <Container>
      <h1>Relatório de Distribuição - Detalhes</h1>
      <hr />
      <section>
        <div className="d-flex justify-content-end">
          <Button
            size="sm"
            className="btn-secondary"
            onClick={() => navigate(-1)}
          >
            Voltar
          </Button>
        </div>
        <ErrorBoundary>
          <GenericTable
            options={{
              columns: columnsRelatorioDistribuicao,
              data: rowDataRelatorioDistribuicao,
            }}
            plugins={[]}
          />
        </ErrorBoundary>
        <ErrorBoundary>
          <GenericTable
            options={{
              columns: columnsRelatorioDistribuicaoFuncionario,
              data: rowDataRelatorioDistribuicaoFuncionario,
            }}
            plugins={[]}
          />
        </ErrorBoundary>
      </section>
    </Container>
  )
}
