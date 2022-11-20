import { CircularProgress } from '@mui/material';
import React from 'react';
import { PreloaderWrapper } from '../styles/Preloader.style';

const Preloader: React.FC = () => {
    return (
        <PreloaderWrapper>
            <CircularProgress />
        </PreloaderWrapper>
    );
}

export default Preloader