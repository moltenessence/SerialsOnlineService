import styled from 'styled-components';

export const PurchasesWrapper = styled.section`
    display: flex;
    flex-direction: column;

    h1 {
        margin-bottom: 0.5em;
    }
`

export const PurchaseItem = styled.div`
   padding: 1em;
    background-color: ${props => props.theme.item};
    opacity: 0.9;
    border-radius: 1em;
    margin-bottom: 5px;

   h3 {
    margin-bottom: 0.5em;
   }

    p {
        padding: 0.2em 0;
    }
`