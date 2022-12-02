import styled from "styled-components";

export const FormWrapper = styled.section`
  margin: 2px;
  width: 50%;
`;

export const FormItem = styled.div`
  padding: 6px;

  input {
    padding: 5px;
  }
  margin-bottom: 5px;
`;
export const Button = styled.button`
  padding: 5px;
  width: 25%;
  letter-spacing: 2px;

  &:hover {
    cursor: pointer;
  }
`;

export const RatingButton = styled.button`
  padding: 5px;
  letter-spacing: 2px;

  &:hover {
    cursor: pointer;
  }
`;

export const SearchForm = styled.div`
display: inline-flex;
width: 1600px;
border: none;
background-color: ${props => props.theme.background};
color: ${props => props.theme.text};
button {
    width:100px;
}
`;

export const ErrorWrapper = styled.button`
  padding: 10px;
  background: #ffb8b8;
  color: black;
  border: none;
  border-radius: 5px;
  letter-spacing: 1px;
  width: 260px;
`;
