import { ThemeProvider } from 'styled-components';
import { darkTheme } from './Common/Themes';
import { AppContainer } from './Components/styles/App.style';
import { GlobalStyles } from './Components/styles/GlobalStyles';
import {useEffect } from 'react';
import Header from './Components/Header';
import Navigation from './Components/Navigation';
import ApplicationRouter from './Components/routing/ApplicationRouter';
import { gapi } from 'gapi-script';
import { GOOGLE_CLIENT_ID } from './Common/Constants';

const App: React.FC = () => {
    
  useEffect(() => {
    function start() {
      gapi.client.init({
        clientId: {GOOGLE_CLIENT_ID},
        scope: ''
    })
  };

    gapi.load('client:auth2', start);
  });

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
