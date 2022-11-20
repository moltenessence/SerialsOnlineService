import styled from 'styled-components';

export const HeaderWrapper  = styled.header`
    letter-spacing: 0.3em;
    padding: 0.8em 1.9em;
    background-color: ${props => props.theme.header};
    display: flex;
    justify-content: space-between;
    box-shadow: 0 0 10px 0 rgba(0,0,0,0.5);

    a {
        text-decoration: none;
        color: ${props => props.theme.text};
        padding-right: 2em;
        padding-top: 0.6em;
        position: relative;
    }

    h1 {
        color: ${props => props.theme.text};
    }

    div {
        opacity: 0;
        position: absolute;
        top: 0px;
        width: 100%;
    }

`