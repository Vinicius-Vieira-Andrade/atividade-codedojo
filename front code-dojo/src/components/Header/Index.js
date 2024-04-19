
import { ContainerHeader, ContainerYuri, TextHeader, YuriAlbertoImage } from "./style"

export const HeaderIn = () => {
    return (
        <ContainerHeader>

            <ContainerYuri>
                <YuriAlbertoImage source={require("../../assets/images.jpg")} />
            </ContainerYuri>

            <TextHeader>Yuri Alberto</TextHeader>
        </ContainerHeader>
    )
}