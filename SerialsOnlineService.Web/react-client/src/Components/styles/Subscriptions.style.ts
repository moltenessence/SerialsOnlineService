import styled from 'styled-components';

export const SubscriptionsWrapper  = styled.section`
    margin: 5px;
`

export const SubscriptionItem  = styled.div`
    padding: 1em;
    background-color: ${props => props.theme.item};
    opacity: 0.97;
    border-radius: 1em;
    box-shadow: 0 10px 10px 0 rgba(0,0,0,0.3);
    margin: 1em;

    h3 {
        margin-bottom: 0.5em;
        letter-spacing: 0.4em;
    }

    p {
        padding: 0.5em 0;
    }
`