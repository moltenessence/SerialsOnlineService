import styled from 'styled-components';

export const AppContainer  = styled.div`
    height: 100vh;
    padding: 1em;

    background: ${props => props.theme.background};
    color: ${props => props.theme.text};
`