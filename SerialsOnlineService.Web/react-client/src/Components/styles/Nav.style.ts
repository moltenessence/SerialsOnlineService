import styled from 'styled-components';

export const NavWrapper  = styled.nav`
    padding: 1em;
    background-color: ${props => props.theme.nav};
    opacity: 0.97;

    a {
        padding: 1em;
        text-decoration: none;
        color: ${props => props.theme.text};
    }

    a:hover {
        opacity: 1;
    }
    
`