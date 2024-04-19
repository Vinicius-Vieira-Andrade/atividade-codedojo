import { ButtonMic } from "./Styles"
import { FontAwesome } from '@expo/vector-icons';

export const AudioButton = ()=>{
    return (
        <ButtonMic>
            <FontAwesome name="microphone" size={100} color="black"  />
        </ButtonMic>
    )
}