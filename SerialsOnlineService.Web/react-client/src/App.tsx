import { ThemeProvider } from 'styled-components';
import { darkTheme } from './Common/Themes';
import { AppContainer } from './Components/styles/App.style';
import { GlobalStyles } from './Components/styles/GlobalStyles';
import Header from './Components/Header';
import Navigation from './Components/Navigation';
import ApplicationRouter from './Components/routing/ApplicationRouter';

const App: React.FC = () => {
  return (
    <ThemeProvider theme={darkTheme}>
      <GlobalStyles />
      <Header />
      <Navigation/>
      <AppContainer>
        <ApplicationRouter />
      </AppContainer>
    </ThemeProvider>
  );
}

export default App;
