import styled from "styled-components";

export const SerialsWrapper = styled.section`
  display: inline-flex;
  flex-wrap: wrap;
`;

export const SerialItem = styled.div`
  width: 30vw;
  padding: 1em;
  background-color: ${(props) => props.theme.item};
  opacity: 0.96;
  border-radius: 1em;
  box-shadow: 0 10px 10px 0 rgba(0, 0, 0, 0.3);
  letter-spacing: 0.1em;
  margin: 0.4em;

  h3 {
    margin-bottom: 0.5em;
    letter-spacing: 0.4em;
  }

  p {
    padding: 0.5em 0;
  }

  button {
    margin-top: 0.5em;
  }
`;

export const RatingText = styled.p`
  font-size: 1.5em;
  letter-spacing: 0.12em;
`;

export const SerialModal = styled.div`
  position: fixed;
`;

export const Available = styled.div`
  padding:5px;
  margin-top:2px;
  color: green;
  opacity:0.9;
  font-size:15px;
`
