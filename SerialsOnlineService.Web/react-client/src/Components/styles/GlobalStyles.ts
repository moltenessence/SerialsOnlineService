import {createGlobalStyle} from 'styled-components';

export const GlobalStyles  = createGlobalStyle`
    @import url(https://fonts.googleapis.com/css2?family=Crimson+Pro:wght@400;700);

    
    * {
        box-sizing: border-box;
        margin: 0;
        padding: 0;
    }

    body {
        font-family: 'Crimson Pro', Open Sans, sans-serif;
        font-size: 20px;
        margin: 0 auto;
    }
`