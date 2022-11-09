import { ColumnDef } from '@tanstack/react-table'
import { useMemo, useEffect, useState } from 'react'

import { Column } from 'react-table'
import axios from 'axios'
import { Button, Container, Modal } from 'react-bootstrap'
import { Funcionario } from '../../types/types'
import { useNavigate } from 'react-router-dom'
import { GenericTable } from '../../components/GenericTable'

export function CadastroDeFuncionariosRoute(): any {
  const navigate = useNavigate()

  const [rowData, setRowData] = useState<any>()
  const [idFuncionario, setIdFuncionario] = useState<number>()
  const [showModalDeleteFuncionario, setShowModalDeleteFuncionario] = useState(
    false,
  )

  const deleteFuncionario = async () => {
    try {
      const response = await axios.delete(
        'http://localhost:5216/api/v1/Funcionario/' + idFuncionario,
      )
      await fetchData()
      setShowModalDeleteFuncionario(false)
    } catch (error) {
      console.error(error)
    }
  }

  const columns: Column<Funcionario>[] = useMemo(
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
        header: 'Área de Atuação',
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
    [],
  )
  const data = useMemo(() => rowData || [], [rowData])

  const tableHooks: ColumnDef<Funcionario>[] = useMemo(
    () => [
      {
        header: 'Ação',
        id: 'actions',
        Cell: ({ row, getValue }: any) => (
          <div className="d-flex gap-2">
            <Button
              size="sm"
              className="btn-warning"
              onClick={() => {
                console.log(row.values.id)
                navigate(
                  '/configuracao/cadastro-de-funcionarios/' +
                    Number(row.values.id),
                )
              }}
            >
              Editar
            </Button>
            <Button
              size="sm"
              className="btn-danger"
              onClick={() => {
                setIdFuncionario(row.values.id)
                setShowModalDeleteFuncionario(true)
              }}
            >
              Deletar
            </Button>
          </div>
        ),
      },
    ],
    [],
  )

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
      const response = await axios.get(
        'http://localhost:5216/api/v1/Funcionario',
      )
      setRowData(response.data)
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    fetchData()
  }, [])

  return (
    <Container>
      <h1>Cadastro de Funcionários</h1>
      <hr />
      <section>
        <div className="d-flex justify-content-end">
          <Button
            size="sm"
            className="btn-success"
            onClick={() => navigate('/configuracao/cadastro-de-funcionarios/0')}
          >
            Adicionar
          </Button>
        </div>
        <GenericTable
          options={{
            columns: columns,
            data: data,
          }}
          plugins={tableHooks}
        />
      </section>
      <Modal show={showModalDeleteFuncionario}>
        <Modal.Header>Deletar funcionário?</Modal.Header>
        <Modal.Body>Realmente deseja deletar esse funcionário?</Modal.Body>
        <Modal.Footer>
          <div className="d-flex gap-2 justify-content-center ">
            <Button
              className="btn-secondary"
              style={{ width: 100 }}
              onClick={() => setShowModalDeleteFuncionario(false)}
            >
              Cancelar
            </Button>
            <Button
              type="submit"
              className="btn-primary"
              style={{ width: 100 }}
              onClick={deleteFuncionario}
            >
              Salvar
            </Button>
          </div>
        </Modal.Footer>
      </Modal>
    </Container>
  )
}
