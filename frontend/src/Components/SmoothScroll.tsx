import { useTransform, motion, useScroll, useSpring } from 'framer-motion';
import { useEffect, useState, useRef } from 'react';
// URL: https://dev.to/ironcladdev/smooth-scrolling-with-react-framer-motion-dih



export default function SmoothScroll({ children }: { children: React.ReactNode; }) {
    const { scrollYProgress } = useScroll();
    const smoothProgress = useSpring(scrollYProgress, { mass: 0.1 })
    const contentRef = useRef<HTMLDivElement>(null);
    const [contentHeight, setContentHeight] = useState(0);

    const y = useTransform(smoothProgress, (value: number) => {
        const scrollDistance = contentHeight - window.innerHeight;
        return scrollDistance > 0 ? value * -scrollDistance : 0;
    });

    // const y = useTransform(smoothProgress, value => {
    //     return value * -(contentHeight - window.innerHeight);
    //   });
    useEffect(() => {
        const handleResize = () => {
            if (contentRef.current) {
                setContentHeight(contentRef.current.scrollHeight)
            }
        }
        window.addEventListener("resize", handleResize);

        return () => {
            window.removeEventListener("resize", handleResize);
        }
    }, [contentRef, children]);

    return (<>
        <div style={{ height: contentHeight }} />

        <motion.div
            className="scrollBody"
            style={{ y }}
            ref={contentRef}
        >
            {children}
        </motion.div>
    </>);
}
