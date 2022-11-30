import React from 'react';
import { EditOutlined } from '@ant-design/icons';
import { Button } from 'antd';

type UpdateButtonProps = {
    callback: () => void;
}

const UpdateButton: React.FC<UpdateButtonProps> = ({ callback }) => {
    return (
        <React.Fragment>
            <Button ghost type="default" onClick={() => callback()} size='middle' icon={< EditOutlined/>} >
                Edit
            </Button>
        </React.Fragment>
    );
}
export default UpdateButton;