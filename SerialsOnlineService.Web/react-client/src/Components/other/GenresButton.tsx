import React from 'react';
import { OrderedListOutlined } from '@ant-design/icons';
import { Button } from 'antd';

type DeleteButtonProps = {
    callback: () => void;
}

const GenresButton: React.FC<DeleteButtonProps> = ({ callback }) => {
    return (
        <React.Fragment>
            <Button ghost type="default" onClick={callback} size='middle' icon={<OrderedListOutlined />} >
                Genres
            </Button>
        </React.Fragment>
    );
}
export default GenresButton;