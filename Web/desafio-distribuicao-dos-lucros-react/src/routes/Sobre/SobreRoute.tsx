import { Container } from 'react-bootstrap'

export function SobreRoute(): any {
  return (
    <Container>
      <h1 className='mb-3'>Sobre</h1>
      <hr />
      <p>Desevolvido por Lukas Araujo Santiago</p>
      <a href='https://github.com/lukas-santiago'>Link para o meu GitHub</a>
      <br />
      <a href='https://www.linkedin.com/in/lukas-santiago/'>Link para o meu Linkdin</a>
    </Container>
  )
}
