import { Formik, FormikHelpers } from 'formik'
import * as yup from 'yup'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import InputGroup from 'react-bootstrap/InputGroup'
import { useState } from 'react'
import { useEffect } from 'react'
import axios from 'axios'
import { Container } from 'react-bootstrap'

const initialValues = {
  valorTotalDisponibilizado: 0,
  salarioMinimo: 1000,
}

const validationSchema = yup.object().shape({
  valorTotalDisponibilizado: yup.number().moreThan(0, 'Deve ser maior que 0').required('Campo inválido'),
  salarioMinimo: yup.number().moreThan(0, 'Deve ser maior que 0').required('Campo inválido'),
})

export function ConfiguracaoCalculoRoute(): any {
  const [formData, setFormData] = useState<any>(null)

  const handleFormSubmit = async (values: any, formikHelpers: FormikHelpers<any>) => {
    await saveData(values)
    formikHelpers.setSubmitting(false)
  }

  async function fetchData() {
    try {
      const response = await axios.get('http://localhost:5216/api/v1/ConfiguracaoCalculo')
      setFormData(response.data)
    } catch (error) {
      console.error(error)
    }
  }

  async function saveData(values: any) {
    try {
      console.log(values)
      await axios.put('http://localhost:5216/api/v1/ConfiguracaoCalculo', {
        ...values,
        id: 0,
      })
      fetchData()
    } catch (error) {
      console.error(error)
    }
  }

  useEffect(() => {
    fetchData()
  }, [])
  return (
    <Container>
      <h1>Configurações do Cálculo</h1>
      <hr />
      <section>
        <h5>Configurações atuais</h5>
        <Formik
          enableReinitialize={true}
          onSubmit={handleFormSubmit}
          initialValues={formData || initialValues}
          validationSchema={validationSchema}
        >
          {({ values, errors, touched, handleBlur, handleChange, handleSubmit, isSubmitting, resetForm }) => (
            <Form onSubmit={handleSubmit}>
              <Form.Group className='mb-3' controlId='valorTotalDisponibilizado'>
                <Form.Label>Valor Total Disponibilizado</Form.Label>
                <InputGroup className='mb-3'>
                  <InputGroup.Text>R$</InputGroup.Text>
                  <Form.Control
                    type='number'
                    name='valorTotalDisponibilizado'
                    aria-label='Quantidade (em reais)'
                    value={values.valorTotalDisponibilizado}
                    onChange={handleChange('valorTotalDisponibilizado')}
                    onBlur={handleBlur}
                    isValid={touched.valorTotalDisponibilizado && !errors.valorTotalDisponibilizado}
                    isInvalid={!!errors.valorTotalDisponibilizado}
                  />
                  <InputGroup.Text>.00</InputGroup.Text>
                </InputGroup>
                <Form.Control.Feedback className='d-block' type='invalid'>
                  {errors.valorTotalDisponibilizado}
                </Form.Control.Feedback>
              </Form.Group>

              <Form.Group className='mb-3' controlId='salarioMinimo'>
                <Form.Label>Salario Mínimo</Form.Label>
                <InputGroup className='mb-3'>
                  <InputGroup.Text>R$</InputGroup.Text>
                  <Form.Control
                    type='number'
                    name='salarioMinimo'
                    aria-label='Quantidade (em reais)'
                    value={values.salarioMinimo}
                    onChange={handleChange('salarioMinimo')}
                    onBlur={handleBlur}
                    isValid={touched.salarioMinimo && !errors.salarioMinimo}
                    isInvalid={!!errors.salarioMinimo}
                  />
                  <InputGroup.Text>.00</InputGroup.Text>
                </InputGroup>
                <Form.Control.Feedback className='d-block' type='invalid'>
                  {errors.salarioMinimo}
                </Form.Control.Feedback>
              </Form.Group>

              <div className='d-flex gap-2 justify-content-center '>
                <Button
                  onClick={() => resetForm()}
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
          )}
        </Formik>
      </section>
    </Container>
  )
}
