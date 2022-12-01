import styled from 'styled-components';

export const AppContainer  = styled.main`
    min-height: 80.3vh;

    background: ${props => props.theme.background};
    color: ${props => props.theme.text};

    padding: 1em 1.7em;
`