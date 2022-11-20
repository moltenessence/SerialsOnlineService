import { ThemeProvider } from 'styled-components';
import { darkTheme } from './Common/Themes';
import { AppContainer } from './Components/styles/App.style';
import { GlobalStyles } from './Components/styles/GlobalStyles';
import {useEffect } from 'react';
import Header from './Components/Header';
import Navigation from './Components/Navigation';
import ApplicationRouter from './Components/routing/ApplicationRouter';
import { gapi } from 'gapi-script';

const App: React.FC = () => {
    
  useEffect(() => {
    function start() {
      gapi.client.init({
        clientId: '364153709208-56ucs5l2p4jc9aao37jb6ek0ubal7g3l.apps.googleusercontent.com',
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
