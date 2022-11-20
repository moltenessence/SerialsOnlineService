import React, { useState } from 'react';
import { Modal } from 'antd';
import { Rating } from "../styles/Serials.style";

type ModalProps = {
    openSerialInfo: React.Dispatch<React.SetStateAction<boolean>>;
}

const SerialModal: React.FC<ModalProps> = ({ openSerialInfo }) => {
    return (
        <Modal title="Game Of Thrones" centered open={true} onOk={()=>openSerialInfo(false)} onCancel={()=>openSerialInfo(false)}>
            <p>Amount of series: 15</p>
            <p>Released: 2012</p>
            <p>Genre: Fantasy</p>
            <p>Subscription: Basic</p>
            <p>Description: He share of first to worse. Weddings and any opinions suitable smallest nay.
                My he houses or months settle remove ladies appear.
                Engrossed suffering supposing he recommend do eagerness.
                Commanded no of depending extremity recommend attention tolerably.
                Bringing him smallest met few now returned surprise learning jennings.
                Objection delivered eagerness he exquisite at do in. Warmly up he nearer mr merely me.</p>
            <Rating>Rating: 9.5</Rating>
        </Modal>
    );
};

export default SerialModal;



