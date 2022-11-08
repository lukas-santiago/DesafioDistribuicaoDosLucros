import { CellContext, ColumnDef, CoreCell } from '@tanstack/react-table'
import { useMemo, useEffect, useState } from 'react'

import BTable from 'react-bootstrap/Table'
import { Hooks, useTable } from 'react-table'
import axios from 'axios'
import { Button, Container } from 'react-bootstrap'
import { Funcionario } from '../../types/types'
import { useNavigate } from 'react-router-dom'

export function CadastroDeFuncionariosRoute(): any {
  const [rowData, setRowData] = useState<any>()
  const navigate = useNavigate()

  const columns: ColumnDef<Funcionario>[] = useMemo(
    () => [
      {
        header: '#',
        accessor: 'id',
      },
      {
        header: 'Matrícula',
        accessor: 'matricula',
      },
      {
        header: 'Nome',
        accessor: 'nome',
      },
      {
        header: 'Area de Atuação',
        accessor: 'areaAtuacao',
      },
      {
        header: 'Cargo',
        accessor: 'cargo',
      },
      {
        header: 'Salário Bruto',
        accessor: 'salarioBruto',
      },
      {
        header: 'Data de Admissão',
        accessor: 'dataAdmissao',
        Cell: parseToDateTimeCell(),
      },
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
    []
  )

  const data = useMemo(() => rowData || [], [rowData])

  const tableHooks = (hooks: any): Hooks =>
    hooks.visibleColumns.push((columns: ColumnDef<Funcionario>[]) => [
      ...columns,
      {
        header: 'Ação',
        id: 'actions',
        Cell: ({ row, getValue }) => (
          <div className='d-flex gap-2'>
            <Button
              size='sm'
              className='btn-warning'
              onClick={() => {
                console.log(row.values.id);
                navigate('/configuracao/cadastro-de-funcionarios/' + Number(row.values.id))
              }}
            >
              Editar
            </Button>
            <Button size='sm' className='btn-danger'>
              Deletar
            </Button>
          </div>
        ),
      },
    ])

  function parseToDateTimeCell(): (({ cell }: any) => JSX.Element) | undefined {
    return ({ cell }: any) => (
      <div>
        {new Date(cell.value).toLocaleString('pt-br', {
          dateStyle: 'short',
          timeStyle: 'short',
        })}
      </div>
    )
  }

  async function fetchData() {
    try {
      const response = await axios.get('http://localhost:5216/api/v1/Funcionario')
      setRowData(response.data)
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    fetchData()
  }, [])

  const { getTableProps, headerGroups, rows, prepareRow } = useTable(
    {
      columns: columns,
      data: data,
    },
    tableHooks
  )

  return (
    <Container>
      <h1>Cadastro de Funcionários</h1>
      <hr />
      <section>
        <div className='d-flex justify-content-end'>
          <Button size='sm' className='btn-success'>
            Adicionar
          </Button>
        </div>
        <BTable className='rounded-5' striped hover {...getTableProps()}>
          <thead>
            {headerGroups.map((headerGroup) => (
              <tr {...headerGroup.getHeaderGroupProps()}>
                {headerGroup.headers.map((column) => (
                  <th {...column.getHeaderProps()}>{column.render('header')}</th>
                ))}
              </tr>
            ))}
          </thead>
          <tbody>
            {rows.map((row, i) => {
              prepareRow(row)
              return (
                <tr {...row.getRowProps()}>
                  {row.cells.map((cell) => {
                    return <td {...cell.getCellProps()}>{cell.render('Cell')}</td>
                  })}
                </tr>
              )
            })}
          </tbody>
        </BTable>
      </section>
    </Container>
  )
}
