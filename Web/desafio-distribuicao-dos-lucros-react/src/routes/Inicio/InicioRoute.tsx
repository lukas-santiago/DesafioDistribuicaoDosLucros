import { Container } from "react-bootstrap";

export function InicioRoute(): any {
  return (
    <Container>
      <h1 className='mb-3'>Desafio de Distribuição do Lucros</h1>
      <hr />
      <p>Aplicação desenvolvida com base em um desafio</p>
      <h4>Descrição</h4>
      <p>
        Uma empresa fechou o ano de operação com lucro e deseja reparti-lo entre seus funcionários, com o objetivo de
        ser justa criou uma regra para a distribuição deste montante por: área, tempo de empresa e faixa salarial (os
        funcionários que ganham menos teriam sua participação incrementada). Para isso foi solicitado ao time de
        tecnologia que desenvolva um sistema onde possa cadastrar os funcionários e que receba um valor máximo para
        distribuir e distribua o montante para os funcionários cadastrados. Tal distribuição segue determinadas regras
        descritas a seguir.
      </p>
    </Container>
  )
}
