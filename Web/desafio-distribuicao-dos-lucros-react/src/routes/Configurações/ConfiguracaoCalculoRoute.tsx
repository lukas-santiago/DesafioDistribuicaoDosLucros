import { Formik } from 'formik'
import * as yup from 'yup'
import Form from 'react-bootstrap/Form'
import Button from 'react-bootstrap/Button'
import InputGroup from 'react-bootstrap/InputGroup'
import { useState } from 'react'
import { useEffect } from 'react'

const initialValues = {
  ValorTotalDisponibilizado: 0,
  SalarioMinimo: 1000,
}

const validationSchema = yup.object().shape({
  ValorTotalDisponibilizado: yup.number().moreThan(0, 'Deve ser maior que 0').required('Este é um campo necessário'),
  SalarioMinimo: yup.number().moreThan(0, 'Deve ser maior que 0').required('Este é um campo necessário'),
})

export function ConfiguracaoCalculoRoute(): any {
  const [formData, setFormData] = useState<any>(null)

  const handleFormSubmit = (values: any) => {
    console.log(values)
  }

  useEffect(() => {
    setFormData({
      ...initialValues,
      ValorTotalDisponibilizado: 100000,
    })
  }, [])
  return (
    <>
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
          {({ values, errors, touched, handleBlur, handleChange, handleSubmit, isSubmitting }) => (
            <Form onSubmit={handleSubmit}>
              <Form.Group className='mb-3' controlId='ValorTotalDisponibilizado'>
                <Form.Label>Valor Total Disponibilizado</Form.Label>
                <InputGroup className='mb-3'>
                  <InputGroup.Text>R$</InputGroup.Text>
                  <Form.Control
                    type='number'
                    name='ValorTotalDisponibilizado'
                    aria-label='Quantidade (em reais)'
                    value={values.ValorTotalDisponibilizado}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isValid={touched.ValorTotalDisponibilizado && !errors.ValorTotalDisponibilizado}
                    isInvalid={!!errors.ValorTotalDisponibilizado}
                  />
                  <InputGroup.Text>.00</InputGroup.Text>
                </InputGroup>
                <Form.Control.Feedback className='d-block' type='invalid'>
                  {errors.ValorTotalDisponibilizado}
                </Form.Control.Feedback>
              </Form.Group>
              <Form.Group className='mb-3' controlId='SalarioMinimo'>
                <Form.Label>Salario Mínimo</Form.Label>
                <InputGroup className='mb-3'>
                  <InputGroup.Text>R$</InputGroup.Text>
                  <Form.Control
                    type='number'
                    name='SalarioMinimo'
                    aria-label='Quantidade (em reais)'
                    value={values.SalarioMinimo}
                    onChange={handleChange}
                    onBlur={handleBlur}
                    isValid={touched.SalarioMinimo && !errors.SalarioMinimo}
                    isInvalid={!!errors.SalarioMinimo}
                  />
                  <InputGroup.Text>.00</InputGroup.Text>
                </InputGroup>
                <Form.Control.Feedback className='d-block' type='invalid'>
                  {errors.SalarioMinimo}
                </Form.Control.Feedback>
              </Form.Group>
              <Button type='submit' disabled={isSubmitting}>
                Salvar
              </Button>
            </Form>
          )}
        </Formik>
      </section>
    </>
  )
}
