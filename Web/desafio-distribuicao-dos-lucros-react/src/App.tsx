import './App.css'
import { Menu, MenuItem, ProSidebarProvider, Sidebar, SubMenu } from 'react-pro-sidebar'
import { Link, Routes, Route } from 'react-router-dom'
import { CadastroDeFuncionariosRoute } from './routes/Configurações/CadastroDeFuncionariosRoute'
import { ConfiguracaoCalculoRoute } from './routes/Configurações/ConfiguracaoCalculoRoute'
import { InicioRoute } from './routes/Inicio/InicioRoute'
import { RelatorioDistribuicaoRoute } from './routes/Relatorios/RelatorioDistribuicaoRoute'
import { SobreRoute } from './routes/Sobre/SobreRoute'

function App() {
  return (
    <ProSidebarProvider>
      <div className='layout-container'>
        <Sidebar>
          <Menu>
            <MenuItem routerLink={<Link to='/' />}>Inicio</MenuItem>
            <SubMenu label='Relatório'>
              <MenuItem routerLink={<Link to='/relatorio/distribuicao' />}>Relatório de Distribuição</MenuItem>
            </SubMenu>
            <SubMenu label='Configurações'>
              <MenuItem routerLink={<Link to='/configuracao/calculo' />}>Configurações do Cálculo</MenuItem>
              <MenuItem routerLink={<Link to='/configuracao/cadastro-de-funcionarios' />}>
                Cadastro de Funcionários
              </MenuItem>
            </SubMenu>
            <MenuItem routerLink={<Link to='/sobre' />}>Sobre</MenuItem>
          </Menu>
        </Sidebar>
        <div className='content-container'>
          <Routes>
            <Route path='/' element={<InicioRoute />} />
            <Route path='/relatorio/distribuicao' element={<RelatorioDistribuicaoRoute />} />
            <Route path='/configuracao/calculo' element={<ConfiguracaoCalculoRoute />} />
            <Route path='/configuracao/cadastro-de-funcionarios' element={<CadastroDeFuncionariosRoute />} />
            <Route path='/sobre' element={<SobreRoute />} />
          </Routes>
        </div>
      </div>
    </ProSidebarProvider>
  )
}

export default App
