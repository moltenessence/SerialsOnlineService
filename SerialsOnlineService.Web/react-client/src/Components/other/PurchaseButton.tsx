import React from 'react';
import { MoneyCollectOutlined } from '@ant-design/icons';
import { Button } from 'antd';

type ButtonProps = {
    callback: () => void;
}

const PurchaseButton: React.FC<ButtonProps> = ({ callback }) => {
    return (
        <React.Fragment>
            <Button ghost type="default" onClick={() => callback()} size='middle' icon={<MoneyCollectOutlined />} >
                Buy
            </Button>
        </React.Fragment>
    );
}
export default PurchaseButton;