import { useNavigate, useParams } from 'react-router-dom'
import { useEffect, useState } from 'react'
import { Funcionario } from '../../types/types'
import axios from 'axios'
import { Formik, FormikHelpers } from 'formik'
import * as yup from 'yup'
import { SchemaOf } from 'yup'
import { Button, Col, Container, Form, InputGroup, Row } from 'react-bootstrap'

const initialValues: Funcionario = {
  id: 0,
  creationDate: new Date(),
  updatedDate: new Date(),
  ativo: true,
  matricula: '',
  nome: '',
  areaAtuacao: 0,
  cargo: 0,
  salarioBruto: 0,
  dataAdmissao: new Date(),
}

const validationSchema: SchemaOf<Funcionario> = yup.object({
  id: yup.number().required(),
  matricula: yup.string().required('Campo necessário'),
  nome: yup.string().required('Campo necessário'),
  areaAtuacao: yup.number().required('Campo necessário'),
  cargo: yup.number().required('Campo necessário'),
  salarioBruto: yup.number().moreThan(0, 'Deve ser maior que zero').required('Campo necessário'),
  dataAdmissao: yup.date().required('Campo necessário'),

  creationDate: yup.date().required(),
  updatedDate: yup.date().required(),
  ativo: yup.boolean().required(),
})

export function FormularioFuncionarioRoute() {
  let { id } = useParams()
  const navigate = useNavigate()

  const [funcionario, setFuncionario] = useState<Funcionario>()

  useEffect(() => {
    fetchData()
  }, [])

  const handleFormSubmit = async (values: any, formikHelpers: FormikHelpers<any>) => {
    console.log(values)
    await saveData(values)
    formikHelpers.setSubmitting(false)
    navigate(-1)
  }

  async function fetchData() {
    try {
      const response = await axios.get('http://localhost:5216/api/v1/Funcionario/' + id)
      setFuncionario(response.data)
    } catch (error) {
      console.error(error)
    }
  }

  async function saveData(values: any) {
    try {
      console.log(values)
      if (Number(id) == 0) {
        await axios.post('http://localhost:5216/api/v1/Funcionario', {
          ...values,
          dataAdmissao: new Date(values.dataAdmissao).toISOString(),
          id: 0,
          areaAtuacao: Number(values.areaAtuacao),
          cargo: Number(values.cargo),
          salarioBruto: Number(values.salarioBruto),
        })
      } else {
        await axios.put('http://localhost:5216/api/v1/Funcionario', values)
      }
      fetchData()
    } catch (error) {
      console.error(error)
    }
  }

  const OptionsAreaAtuacao = [
    { value: 0, text: 'Diretoria' },
    { value: 1, text: 'Relacionamento com o Cliente' },
    { value: 2, text: 'Serviços Gerais' },
    { value: 3, text: 'Contabilidade' },
    { value: 3, text: 'Financeiro' },
    { value: 3, text: 'Tecnologia' },
  ]
  const OptionsCargo = [
    { value: 0, text: 'Funcionário' },
    { value: 1, text: 'Estagiário' },
  ]

  return (
    <Container>
      <h1>{Number(id) == 0 ? 'Adicionar' : 'Editar'} Funcionário</h1>
      <hr />
      <Formik
        enableReinitialize={true}
        onSubmit={handleFormSubmit}
        initialValues={funcionario || initialValues}
        validationSchema={validationSchema}
      >
        {({ values, errors, touched, handleBlur, handleChange, handleSubmit, isSubmitting, resetForm }) => {
          const [dataformat, setDataFormat] = useState(new Date(values.dataAdmissao).toISOString().substring(0, 16))

          function getProps(name: keyof Funcionario) {
            return {
              name: name,
              onChange: handleChange(name),
              onBlur: handleBlur,
              isValid: touched[name] && !errors[name],
              isInvalid: !!errors[name],
            }
          }

          useEffect(() => {
            setDataFormat(new Date(values.dataAdmissao).toISOString().substring(0, 16))
          }, [values.dataAdmissao])
          return (
            <Form onSubmit={handleSubmit}>
              <Row>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Matrícula</Form.Label>
                    <Form.Control type='text' value={values.matricula} {...getProps('matricula')} />
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.matricula}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Nome</Form.Label>
                    <Form.Control type='text' value={values.nome} {...getProps('nome')} />
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.nome}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Área de Atuação</Form.Label>
                    <Form.Select value={values.areaAtuacao} {...getProps('areaAtuacao')}>
                      {OptionsAreaAtuacao.map((opt, index) => (
                        <option key={index} value={opt.value}>
                          {opt.text}
                        </option>
                      ))}
                    </Form.Select>
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.areaAtuacao}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Cargo</Form.Label>
                    <Form.Select value={values.cargo} {...getProps('cargo')}>
                      {OptionsCargo.map((opt, index) => (
                        <option key={index} value={opt.value}>
                          {opt.text}
                        </option>
                      ))}
                    </Form.Select>
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.cargo}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Salário Bruto</Form.Label>
                    <InputGroup className='mb-3'>
                      <InputGroup.Text>R$</InputGroup.Text>
                      <Form.Control type='number' value={values.salarioBruto} {...getProps('salarioBruto')} />
                      <InputGroup.Text>.00</InputGroup.Text>
                    </InputGroup>
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.salarioBruto}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
                <Col lg={{ span: '3' }} md={{ span: '6' }}>
                  <Form.Group className='mb-3'>
                    <Form.Label>Data de Admissão</Form.Label>
                    <Form.Control type='datetime-local' value={dataformat} {...getProps('dataAdmissao')} />
                    <Form.Control.Feedback className='d-block' type='invalid'>
                      {errors.dataAdmissao}
                    </Form.Control.Feedback>
                  </Form.Group>
                </Col>
              </Row>
              <div className='d-flex gap-2 justify-content-center '>
                <Button
                  onClick={() => navigate(-1)}
                  disabled={isSubmitting}
                  className='btn-secondary'
                  style={{ width: 100 }}
                >
                  Cancelar
                </Button>
                <Button type='submit' disabled={isSubmitting} className='btn-primary' style={{ width: 100 }}>
                  Salvar
                </Button>
              </div>
            </Form>
          )
        }}
      </Formik>
    </Container>
  )
}
