import { Button, Container } from 'react-bootstrap'
import { useNavigate } from 'react-router-dom'
import { Column } from 'react-table'
import { RelatorioDistribuicao } from '../../types/types'
import { ColumnDef } from '@tanstack/react-table'
import { useMemo, useState, useEffect } from 'react'
import axios from 'axios'
import { GenericTable } from '../../components/GenericTable'
import { ErrorBoundary } from '../../components/ErrorBoundary'

export function RelatorioDistribuicaoRoute() {
  const navigate = useNavigate()
  const [rowDataState, setRowDataState] = useState<RelatorioDistribuicao[]>([])

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

  const tableHooks: ColumnDef<RelatorioDistribuicao>[] = useMemo(
    () => [
      {
        header: 'Ação',
        id: 'actions',
        Cell: ({ row, getValue }: any) => (
          <div className="d-flex gap-2">
            <Button
              size="sm"
              variant="primary"
              onClick={() => {
                console.log(row.values.id)
                navigate('/relatorio/distribuicao/' + Number(row.values.id))
              }}
            >
              Visualizar
            </Button>
          </div>
        ),
      },
    ],
    [],
  )
  const columns: Column<RelatorioDistribuicao>[] = useMemo(
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
  const rowData = useMemo(() => rowDataState || [], [rowDataState])

  const fetchData = async () => {
    try {
      const response = await axios.get(
        'http://localhost:5216/api/v1/RelatorioDistribuicao',
      )
      setRowDataState(response.data)
    } catch (error) {
      console.error(error)
    }
  }
  const generateReport = async () => {
    try {
      const response = await axios.post(
        'http://localhost:5216/api/v1/RelatorioDistribuicao',
      )
      await fetchData()
      navigate('/relatorio/distribuicao/' + Number(response.data.id))
    } catch (error) {
      console.error(error)
    }
  }
  useEffect(() => {
    fetchData()
  }, [])
  return (
    <Container>
      <h1>Relatório de Distribuição</h1>
      <hr />
      <section>
        <ErrorBoundary>
          <div className="d-flex justify-content-end">
            <Button size="sm" className="btn-success" onClick={generateReport}>
              Gerar relatório
            </Button>
          </div>
          <GenericTable
            options={{
              columns,
              data: rowData,
            }}
            plugins={tableHooks}
          />
        </ErrorBoundary>
      </section>
    </Container>
  )
}
