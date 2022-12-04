import styled from "styled-components";

export const GenresWrapper = styled.section`
  padding: 1em;
  letter-spacing: 0.1em;
  border-radius: 1em;
  margin: 0;

  h1 {
    margin-bottom: 0.5em;
   }
`;

export const GenreItem = styled.div`
  padding: 1.4em;
  background-color: ${(props) => props.theme.item};
  opacity: 0.9;
  border-radius: 1em;
  margin-bottom: 5px;
`;

export const GenreRaw = styled.p`
  margin-bottom: 3px;
`;
