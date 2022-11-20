import React from 'react';
import { Modal } from 'antd';
import { Rating } from "../styles/Serials.style";
import { ISerial } from '../../Common/Models/ISerial';

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
    serial: ISerial | null;
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo, serial }) => {
    return (
        <Modal title={serial?.name} centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: {serial?.amountOfSeries}</p>
            <p>Released: {serial?.releaseYear}</p>
            <p>Genre: {serial?.genre}</p>
            <p>Subscription: Basic</p>
            <p>Description: {serial?.description}</p>
            <Rating>Rating: {serial?.rating}</Rating>
        </Modal>
    );
};

export default SerialModal;



