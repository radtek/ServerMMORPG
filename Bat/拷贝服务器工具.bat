color 2f

set sc1=F:\SangoGai\Server\APublish\Config
set des1=F:\SangoGai\Server\APublish\���ݲ�ѯ����\Config
xcopy %sc1%\Xml\*.* %des1%\Xml\ /y

set sc=F:\SangoGai\Server\APublish\
set des=F:\SangoGai\Public\
xcopy %sc%��񹤾�\*.* %des%��񹤾�\ /y
xcopy %sc%������\*.* %des%������\ /y
xcopy %sc%���ݲ�ѯ����\*.* %des%���ݲ�ѯ����\ /y
xcopy %sc%���ݲ�ѯ����\Config\Xml\*.* %des%���ݲ�ѯ����\Config\Xml\ /y
xcopy %sc%��¼��ѯ����\*.* %des%��¼��ѯ����\ /y

pause