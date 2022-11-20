import styled from 'styled-components';

export const SerialsWrapper  = styled.section`
    display: flex;
    flex-wrap: wrap;
    justify-content: space-between;
    flex-direction: row;
`

export const SerialItem  = styled.div`
    width: 31vw;
    padding: 1em;
    background-color: ${props => props.theme.item};
    opacity: 0.97;
    border-radius: 1em;
    box-shadow: 0 10px 10px 0 rgba(0,0,0,0.3);
    letter-spacing: 0.1em;

    h3 {
        margin-bottom: 0.5em;
        letter-spacing: 0.4em;
    }

    p {
        padding: 0.5em 0;
    }
`

export const Rating = styled.p`
    font-size: 1.5em;
    letter-spacing: 0.12em;
`

export const SerialModal = styled.div`
    position: fixed;
    
`