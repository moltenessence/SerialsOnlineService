import React from 'react';
import { InfoOutlined } from '@ant-design/icons';
import { Button } from 'antd';

type InfoButtonProps = {
    callback: React.Dispatch<React.SetStateAction<boolean>>;
}

const InfoButton: React.FC<InfoButtonProps> = ({ callback }) => {
    return (
        <React.Fragment>
            <Button ghost type="default" onClick={() => callback(true)} size='middle' icon={<InfoOutlined />} >
                Show More
            </Button>
        </React.Fragment>
    );
}
export default InfoButton;