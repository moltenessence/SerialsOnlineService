import { ThemeProvider } from 'styled-components';
import { darkTheme } from './Common/themes';
import { AppContainer } from './Components/styles/App.style';
import { GlobalStyles } from './Components/styles/GlobalStyles';

function App() {
  return (
    <div>
      <ThemeProvider theme={darkTheme}>
      <GlobalStyles />
        <AppContainer>
          hello
        </AppContainer>
      </ThemeProvider>
    </div>
  );
}

export default App;
