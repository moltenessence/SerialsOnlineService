import React from 'react';
import { Modal } from 'antd';
import { Rating } from "../styles/Serials.style";
import { ISerialWithRatings } from '../../Common/Models/ISerialWithRatings';
import Ratings from '../Ratings';

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
    serialInfo: ISerialWithRatings | null;
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo, serialInfo }) => {

    const serial = serialInfo?.serial;
    console.log(serialInfo);

    return (
        <Modal title={serial?.name} centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: {serial?.amountOfSeries}</p>
            <p>Released: {serial?.releaseYear}</p>
            <p>Genre: {serial?.genre}</p>
            <p>Description: {serial?.description}</p>
            <Rating>Rating: {serialInfo?.ratings.average}</Rating>
            <Ratings ratings={serialInfo?.ratings.serialRatings}/>
        </Modal>
    );
};

export default SerialModal;



