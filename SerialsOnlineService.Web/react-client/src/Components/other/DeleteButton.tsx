import React from 'react';
import { DeleteOutlined } from '@ant-design/icons';
import { Button } from 'antd';

type DeleteButtonProps = {
    callback: () => void;
}

const DeleteButton: React.FC<DeleteButtonProps> = ({ callback }) => {
    return (
        <React.Fragment>
            <Button ghost type="default" onClick={callback} size='middle' icon={<DeleteOutlined />} >
                Delete
            </Button>
        </React.Fragment>
    );
}
export default DeleteButton;